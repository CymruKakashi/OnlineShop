import { Component, Inject } from '@angular/core';


@Component({
  selector: 'app-export-csv-component',
  templateUrl: './export-csv.component.html',
})
export class ExportCsvComponent {
  private baseUrl: string;

  constructor(@Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  export()
  {
    window.open(this.baseUrl + 'product/export', "_blank");
  }

}
