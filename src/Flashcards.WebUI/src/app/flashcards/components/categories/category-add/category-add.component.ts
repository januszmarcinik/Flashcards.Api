import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';

import {Category} from '../../../models/category';
import {CategoriesService} from '../../../services/categories.service';
import {TOPICS} from '../../../../../constans/constans';
import {HttpErrorResponse} from '@angular/common/http';

@Component({
  selector: 'app-category-add',
  templateUrl: './category-add.component.html',
  styleUrls: ['./category-add.component.less']
})
export class CategoryAddComponent implements OnInit {

  topic: string;
  category: Category;
  categoryForm: FormGroup;
  errors: string;

  constructor(private route: ActivatedRoute,
              private categoriesService: CategoriesService,
              private router: Router,
              private formBuilder: FormBuilder) {
  }

  ngOnInit() {
    this.topic = this.route.snapshot.paramMap.get('topic');
    this.categoryForm = this.buildForm();
  }

  buildForm() {
    let topicValue = TOPICS.find(x => x.route == this.topic).value;
    return this.formBuilder.group({
      name: new FormControl('', [Validators.required, Validators.maxLength(32)]),
      topic: new FormControl(topicValue, Validators.required)
    })
  }

  save() {
    this.categoriesService.add(this.topic, this.categoryForm.value)
      .subscribe((response) => {
        if (response.ok) {
          this.router.navigate([`/flashcards/topics/${this.topic}/categories`]);
        }
      }, (ex: HttpErrorResponse) => {
        this.errors = ex.error.message;
      });
  }

  goBack(): void {
    this.router.navigate([`/flashcards/topics/${this.topic}/categories`]);
  }

}
