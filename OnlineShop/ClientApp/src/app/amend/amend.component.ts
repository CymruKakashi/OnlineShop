import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-amend-component',
  templateUrl: './amend.component.html',
})
export class AmendComponent {
  public fruits: Product[];
  public boundRefresh: Function;
  private http: HttpClient;
  private baseUrl: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;
    this.getProducts();
    this.boundRefresh = this.refreshProducts.bind(this);
  }

  getProducts()
  {
    this.http.get<Product[]>(this.baseUrl + 'product').subscribe(result => {
      this.fruits = result.filter(x => x.productTypeId === 1);
      this.fruits.sort((a, b) => {
        return a.name.toLowerCase().localeCompare(b.name.toLowerCase());
      });
    }, error => console.error(error));
  }

  refreshProducts()
  {
    console.log("callback");
    this.getProducts();
  }
}
