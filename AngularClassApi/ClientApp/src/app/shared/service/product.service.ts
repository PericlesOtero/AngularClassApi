import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Product } from '../models/product';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private serviceUrl = this.baseUrl + "v1/product";

  constructor(private httpClient: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  public getProducts(): Observable<Product[]> {
    return this.httpClient.get<Product[]>(this.serviceUrl);
  }
}
