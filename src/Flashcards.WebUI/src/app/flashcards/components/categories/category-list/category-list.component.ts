import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import 'rxjs/add/operator/filter';
import { Subscription } from "rxjs/Subscription";
import { MatDialog } from '@angular/material';

import { CategoriesService } from '../../../services/categories.service';
import { Category } from '../../../models/category';
import { ConfirmDeleteComponent } from '../../../../shared/components/confirm-delete/confirm-delete.component';
import { HttpErrorResponse } from '@angular/common/http';
import { AlertService } from '../../../../shared/services/alert.service';

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: [ './category-list.component.less' ]
})
export class CategoryListComponent implements OnInit, OnDestroy {

  topic: string;
  categories: Category[];
  subscription: Subscription;

  constructor(private route: ActivatedRoute,
              private categoriesService: CategoriesService,
              private router: Router,
              private dialog: MatDialog,
              private alertService: AlertService) {
    this.subscription = new Subscription();
  }

  ngOnInit() {
    this.topic = this.route.snapshot.paramMap.get('topic');
    const subscriptionRouterParams = this.route.params
      .subscribe(param => {
        this.loadCategories(param.topic);
      });

    this.subscription.add(subscriptionRouterParams);
    this.loadCategories(this.topic);
  }

  loadCategories(topic): void {
    this.categoriesService.getByTopic(topic)
      .subscribe((categories) => {
        this.categories = categories.body;
      }, (ex: HttpErrorResponse) => {
        this.alertService.handleError(ex);
      })
  }

  add() {
    this.router.navigate([ `/flashcards/topics/${this.topic}/categories/add` ]);
  }

  edit(category: Category) {
    this.router.navigate([ `/flashcards/topics/${this.topic}/categories/${category.name}` ]);
  }

  delete(category: Category) {
    let dialogRef = this.dialog.open(ConfirmDeleteComponent, {
      data: {name: category.name}
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.categoriesService.remove(this.topic, category)
          .subscribe((response) => {
            if (response.ok) {
              this.loadCategories(this.topic);
            }
          }, (ex: HttpErrorResponse) => {
            this.alertService.handleError(ex);
          });
      }
    });
  }

  goToDecks(category: Category) {
    this.router.navigate([ `/flashcards/topics/${this.topic}/categories/${category.name}/decks` ]);
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }
}
