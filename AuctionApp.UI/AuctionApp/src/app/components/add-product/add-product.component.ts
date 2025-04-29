import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CategoryService } from 'src/app/_services/category.service';
import { ProductService } from 'src/app/_services/product.service';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css'],
})
export class AddProductComponent implements OnInit {
  productForm!: FormGroup;
  categories: any[] = [];
  selectedFile: any | null = null;

  constructor(
    private fb: FormBuilder,
    private productService: ProductService,
    private categoryService: CategoryService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.initForm();
    this.loadCategories();
  }

  initForm(): void {
    this.productForm = this.fb.group({
      name: ['', [Validators.required, Validators.pattern('^[a-zA-Z ]+$')]],
      description: ['', [Validators.required, Validators.maxLength(500)]],
      startingPrice: [null, [Validators.required, Validators.min(1)]],
      auctionDuration: [null, [Validators.required, Validators.min(1)]],
      category: ['', Validators.required],
      reservedPrice: [null, [Validators.required, Validators.min(1)]],
      productImage: [null, [Validators.required]],
    });
  }

  loadCategories(): void {
    this.categoryService.getAllCategories().subscribe(
      (response: any) => {
        this.categories = response.result;
      },
      (error) => {
        console.error('Error fetching categories:', error);
      }
    );
  }

  onFileSelected(event: any): void {
    const file = event.target.files[0];
    if (file) {
      this.selectedFile = file;
    }
  }

  onSubmit(): void {
    if (this.productForm.valid) {
      const selectedCategoryId = Number(
        this.productForm.get('category')?.value
      );
      const selectedCategory = this.categories.find(
        (cat) => cat.id === selectedCategoryId
      );
      const formData = new FormData();

      Object.keys(this.productForm.value).forEach((key) => {
        if (key === 'category') {
          formData.append(
            'category',
            selectedCategory ? selectedCategory.name : ''
          );
        } else if (key !== 'productImage') {
          formData.append(key, this.productForm.get(key)?.value);
        }
      });

      if (this.selectedFile) {
        formData.append(
          'productImage',
          this.selectedFile,
          this.selectedFile.name
        );
      }
      this.productService.createProduct(formData).subscribe(
        (response: any) => {
          if (response.isSuccess) {
            alert(response.message);
            this.router.navigate(['/']);
          } else {
            alert(response.message);
          }
        },
        (error) => {
          console.error('Error creating product:', error);
        }
      );
    }
  }
}
