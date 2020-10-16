import { Component, Input, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-update-product',
  template: `
    <div class="input-group mb-3">
      <div class="input-group-prepend">
        <span class="input-group-text" id="basic-addon1">Price</span>
      </div>
      <input type="text" class="form-control" placeholder="Price" aria-label="Price" aria-describedby="basic-addon1"
         #newPrice
        (keyup.enter)="setNewPrice(newPrice.value)"
        (blur)="setNewPrice(newPrice.value); newPrice.value='' "
      >
    </div>
    <button type="button" class="btn btn-primary" (click)="setNewPrice(newPrice.value)">Update</button>
  `
})
export class UpdateProductComponent {
  @Input()
  productId: number;
  @Input()
  refreshCallback: Function;
  private http: HttpClient;
  private baseUrl: string;
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string)
  {
    this.http = http;
    this.baseUrl = baseUrl;
  }

  setNewPrice(newPrice: string) {
    if (newPrice) {
      let priceUpdate: ProductPriceUpdate =
      {
        productId: this.productId,
        productPrice: Number(newPrice)
      };
      this.http.post<ProductPriceUpdate>(this.baseUrl + 'product', priceUpdate).subscribe(result => {
        this.refreshCallback();
      }, error => console.error(error));

    }
  }
}
