import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BookFinderComponent } from './book-finder.component';

describe('BookFinderComponent', () => {
  let component: BookFinderComponent;
  let fixture: ComponentFixture<BookFinderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BookFinderComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BookFinderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
