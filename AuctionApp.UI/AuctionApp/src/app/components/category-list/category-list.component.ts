import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { CategoryService } from 'src/app/_services/category.service';

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.css'],
})
export class CategoryListComponent implements OnInit {
  categories: any[] = [];
  loading: boolean = true;
  newCategory = { name: '' };

  constructor(
    private categoryService: CategoryService  ) {}

  ngOnInit(): void {
    this.getAllCategories();
  }

  getAllCategories(): void {
    this.loading = true;
    this.categoryService.getAllCategories().subscribe(
      (response: any) => {
        this.categories = response.result;
        this.loading = false;
      },
      (error) => {
        console.error('Error fetching expenses:', error);
        this.loading = false;
      }
    );
  }

  addCategory(form: NgForm): void {
    if (form.valid) {
      this.categoryService.createCategory(this.newCategory).subscribe(
        (response: any) => {
          console.log('Category created successfully.');
          this.getAllCategories();
          this.newCategory.name = '';
          form.resetForm();
        },
        (error) => {
          console.error('Error in creating category:', error);
        }
      );
    }
  }
}
