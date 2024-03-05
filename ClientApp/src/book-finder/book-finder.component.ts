import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { Book } from 'src/app/shared/models/book';

@Component({
  selector: 'app-book-finder',
  templateUrl: './book-finder.component.html',
  styleUrls: ['./book-finder.component.css']
})
export class BookFinderComponent implements OnInit {
  type: any;
  value: any;
  books: Book[];

  constructor(private http: HttpClient, @Inject('BASE_URL')private baseUrl: string) {
    this.books = [];
   }

  ngOnInit(): void {
  }


  search() {

    if(this.value && !this.type){
      alert('Choose the type')
      return;
    }

    var url = !this.value? "" : `?type=${this.type}&value=${this.value}`;
    this.http.get<Book[]>(this.baseUrl + 'api/books'+ url).subscribe(res => {
      this.books =  res;
    })
  }

}
