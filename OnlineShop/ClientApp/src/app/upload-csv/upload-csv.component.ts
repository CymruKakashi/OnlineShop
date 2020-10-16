import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-upload-csv-component',
  templateUrl: './upload-csv.component.html',
})
export class UploadCsvComponent {

  private http: HttpClient;
  private baseUrl: string;
  private showUploadSuccess = false;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;
  }


  uploadFile(files: FileList)
  {
    const file: File = files.item(0);
    const reader = new FileReader();
    reader.onload = () => {
      const products = this.csvToJson(reader.result as string);
      console.log(products);
      this.http.post<ProductUpload>(this.baseUrl + 'product/upload', products).subscribe(result => {
        this.showUploadSuccess = true;
      }, error => console.error(error));
    }
    reader.readAsText(file);
  }

  csvToJson(text: string)
  {
    const products: ProductUpload[] = [];
    const lines = text.split('\n');
    for (let i = 1; i < lines.length; i++)
    {
      let line: string = lines[i];
      line = line.replace("\r", "");
      const columns: string[] = line.split(",");
      if (columns[0] !== "") {
        products.push({
          name: columns[0],
          price: Number(columns[1]),
          quantity: Number(columns[2]),
          updatedDate: columns[3]
        });
      }

    }
    return products;
  }
}

interface ProductUpload {
  name: string;
  price: number;
  quantity: number;
  updatedDate: string;
}
