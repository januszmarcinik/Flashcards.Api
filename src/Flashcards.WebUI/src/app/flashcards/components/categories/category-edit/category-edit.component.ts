import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';

import {Category} from '../../../models/category';
import {CategoriesService} from '../../../services/categories.service';
import {TOPICS} from '../../../../../constans/constans';
import {HttpErrorResponse} from '@angular/common/http';

@Component({
  selector: 'app-category-edit',
  templateUrl: './category-edit.component.html',
  styleUrls: ['./category-edit.component.less']
})
export class CategoryEditComponent implements OnInit {

  topic: string;
  categoryName: string;

  category: Category;

  categoryForm: FormGroup;
  topics = TOPICS;

  errors: string;

  constructor(private route: ActivatedRoute,
              private categoriesService: CategoriesService,
              private router: Router,
              private formBuilder: FormBuilder) {
  }

  ngOnInit() {
    this.topic = this.route.snapshot.paramMap.get('topic');
    this.categoryName = this.route.snapshot.paramMap.get('category');
    this.loadCategory(this.categoryName);
    this.categoryForm = this.buildForm();
  }

  buildForm() {
    return this.formBuilder.group({
      id: new FormControl('', Validators.required),
      name: new FormControl('', [Validators.required, Validators.maxLength(32)]),
      topic: new FormControl('', Validators.required)
    });
  }

  loadCategory(name: string): void {
    this.categoriesService.getByName(this.topic, name)
      .subscribe((category) => {
        console.log(category);
        this.category = category.body;
        this.categoryForm.setValue({
          id: this.category.id,
          name: this.category.name,
          topic: this.category.topic
        });
      });
  }

  save() {
    this.categoriesService.edit(this.topic, this.categoryForm.value)
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
