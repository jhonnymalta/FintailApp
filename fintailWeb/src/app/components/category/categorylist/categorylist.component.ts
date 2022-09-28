import { Component, OnInit } from '@angular/core';
import { Category } from '../shared/Category.model';
import { CategoryService } from '../shared/category.service';

@Component({
  selector: 'app-categorylist',
  templateUrl: './categorylist.component.html',
  styleUrls: ['./categorylist.component.css'],
})
export class CategorylistComponent implements OnInit {
  categories: Category[] = [];
  constructor(private categoryService: CategoryService) {}

  ngOnInit(): void {
    console.log('chegou aqui');
    this.categoryService.getAll().subscribe({
      next: (data) => (this.categories = data),
    });
  }
}
