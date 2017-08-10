import { Component, OnInit, Output,EventEmitter, Input } from '@angular/core';
import { Data } from '../../../data/Data';
import { Article } from '../../models/Article';

@Component({
  selector: 'asidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']})

export class Sidebar {  
  @Input() articles: Array<Article>;
  @Output() onArticleClick = new EventEmitter<number>();

  articleClick(article) {
    this.onArticleClick.emit(article.id)
  }
}
