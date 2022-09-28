import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { Category } from './Category.model';

@Injectable({
  providedIn: 'root',
})
export class CategoryService {
  private APIPATH: string = 'https://localhost:7045/categories';
  constructor(private http: HttpClient) {}

  getAll(): Observable<Category[]> {
    console.log('get all funfou');
    return this.http
      .get(this.APIPATH)
      .pipe(catchError(this.handleError), map(this.jsonDataToCategories));
  }
  getById(id: number): Observable<Category> {
    const url = `${this.APIPATH}/${id}`;
    return this.http
      .get(url)
      .pipe(catchError(this.handleError), map(this.jsonDataToCategorie));
  }
  create(category: Category): Observable<Category> {
    return this.http.post(this.APIPATH, category);
  }
  update(category: Category): Observable<Category> {
    const url = `${this.APIPATH}/${category.id}`;
    return this.http.put(url, category).pipe(
      catchError(this.handleError),
      map(() => category)
    );
  }
  delete(id: number): Observable<any> {
    const url = `${this.APIPATH}/${id}`;
    return this.http.delete(url).pipe(
      catchError(this.handleError),
      map(() => null)
    );
  }

  //methods
  private jsonDataToCategories(jsonData: any[]): Category[] {
    const categories: Category[] = [];

    jsonData.forEach((el) => categories.push(el as Category));
    return categories;
  }
  private handleError(error: any): Observable<any> {
    console.log('Erro na requisição => ', error);
    return throwError(error);
  }
  private jsonDataToCategorie(jsonData: any): Category {
    return jsonData as Category;
  }
}
