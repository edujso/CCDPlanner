import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { FileSelectDirective, FileDropDirective, FileUploader, Headers, FileUploaderOptions } from 'ng2-file-upload/ng2-file-upload';
import { VendorService } from "app/services/vendor.service";
import * as FileSaver from 'file-saver';
import { Vendor } from '../../model/vendor';
import { ToastService } from '../../blocks/toast';

const _URL = 'http://localhost:56047/api/files/importExcel';

@Component({
  selector: 'app-inout-excel',
  templateUrl: './inout-excel.component.html',
  styleUrls: ['./inout-excel.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class InoutExcelComponent implements OnInit {

  public myHeaders: Headers[] = [];
  vendors: Vendor[];
  public selectedVendor: Vendor;

  public options: FileUploaderOptions = {};  

  public uploader: FileUploader = new FileUploader(
    {
      url: _URL,
      headers: <Headers[]>[
        { name: 'Content-Type', value: 'multipart/form-data' },
        { name: 'Access-Control-Allow-Credentials', value: true },
        { name: 'WithCredentials', value: true }
      ]
    });

  public hasBaseDropZoneOver: boolean = false;
  public hasAnotherDropZoneOver: boolean = false;

  constructor(
    private _vendorService: VendorService,
    private _toastService: ToastService)
  {
    this.options.headers = [{ name: 'Access-Control-Allow-Origin', value: 'http://localhost:4200' }];
    this.uploader.setOptions(this.options);
  }

  ngOnInit() {
    this.getVendors();
  }

  public fileOverBase(e: any): void {
    this.hasBaseDropZoneOver = e;
  }

  public fileOverAnother(e: any): void {
    this.hasAnotherDropZoneOver = e;
  }

  getVendors() {
    this._vendorService.getAll().subscribe(
      vendors => {
        this.vendors = vendors;
      }
    );
  };

  exportExcel() {

    if (this.selectedVendor == null) {
      this._toastService.activate("Please select vendor before continuing");
    }
    else {
      this._vendorService.export(this.selectedVendor.id)
        .subscribe(blob => {

          /*
           var downloadUrl= URL.createObjectURL(blob)
           window.open(downloadUrl, "_blank");
           */

          // Doing it this way allows you to name the file
          var link = document.createElement('a');
          link.href = window.URL.createObjectURL(blob);
          link.download = "DatabaseExample.xlsx";
          link.click();
        });
    }
  }
}
