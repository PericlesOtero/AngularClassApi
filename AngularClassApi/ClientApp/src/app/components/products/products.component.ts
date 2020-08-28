import { Component, OnInit } from '@angular/core';

import { Product } from '../../shared/models/product';
import { ProductService } from '../../shared/service/product.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent implements OnInit {
  public products: Product[];
  public productSelected: Product;
  constructor(private productService: ProductService) { }

  ngOnInit(): void {
    this.productService.getProducts().subscribe(r => this.products = r);
  }

  public onProductSelect(product: Product): void {
    this.productSelected = product;
  }

}
