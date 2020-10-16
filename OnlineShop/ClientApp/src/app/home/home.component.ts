import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public fruits: Product[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Product[]>(baseUrl + 'product').subscribe(result => {
      this.fruits = result.filter(x => x.productTypeId === 1);
      this.fruits.sort((a, b) => {
        return (new Date(b.updatedDate) as any) - (new Date(a.updatedDate) as any);
      });
    }, error => console.error(error));
  }
}
