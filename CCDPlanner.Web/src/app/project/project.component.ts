import { Component, OnInit } from '@angular/core';
import { Category } from '../model/category';
import { CategoryService } from '../services/category.service';

@Component({
  selector: 'app-project',
  templateUrl: './project.component.html',
  styleUrls: ['./project.component.css']
})
export class ProjectComponent implements OnInit {

  public categories: Category[];
  public toggle: boolean = false;

  constructor(private categoryService: CategoryService) {

  }

  ngOnInit() {
    this.getCategories();
  }

  getCategories() {
    this.categoryService.getAll().subscribe(
      categories => this.categories = categories
    );
  }

  toggleAllCategories(categories: Category[], toggle: boolean) {
    this.toggle = toggle;

    categories.forEach(c => {
      c.expanded = toggle;
      if (c.childrenCategories != null) {
        this.toggleAllCategories(c.childrenCategories, toggle)
      }
    });
  }

}
