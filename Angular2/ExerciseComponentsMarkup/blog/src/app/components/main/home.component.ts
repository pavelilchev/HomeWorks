import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Data } from '../../../data/Data';
import { Article } from '../../models/Article';

@Component({
  selector: 'home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class Home {
  private articles: Array<Article>
  private article: Article
  private fontSize = 12;
  private color = 'black';
  private background = 'white';

  ngOnInit() {
    this.articles = Data.getArticles();
    if (this.articles.length > 0) {
      this.article = this.articles[0];
    }
  }

  onArticleClick(id: number) {
    let article = this.articles.find(a => a.id == id);
    if (article != null) {
      this.article = article;
    }
  }

  fontChange(operator) {
    if(operator == 'down') {
      this.fontSize--;
      if(this.fontSize < 8) {
        this.fontSize = 8;
      }
    } else {
      this.fontSize++;
      if(this.fontSize > 24) {
        this.fontSize = 24;
      }
    }
  }

   onColorChange(event) {
     this.color = event.target.value;
  }

  onBackground(event) {
     this.background = event.target.value;
  }
}