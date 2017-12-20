import { Component, OnInit, Input } from '@angular/core';
import { Category } from '../model/category';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {
  @Input() categories: Array<Category>;

  constructor() { }

  ngOnInit() {
  }

  toggle(category: Category) {
    category.expanded = !category.expanded;
  }

  check(category: Category) {
    category.checked = !category.checked;
  }

}
