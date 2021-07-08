import { Component, OnInit, Sanitizer } from '@angular/core';
import { Router } from '@angular/router';
import * as ClassicEditor from '@ckeditor/ckeditor5-build-classic';
import CKFinder from '@ckeditor/ckeditor5-ckfinder/src/ckfinder';
import { ApiService } from '../../../services/api.service';
import { BaseService } from '../../../services/base.service';
import { race } from 'rxjs';
import { DomSanitizer } from '@angular/platform-browser';
import { ToastrService } from 'ngx-toastr';
@Component({

  selector: 'app-bai-viet-create',
  templateUrl: './bai-viet-create.component.html',
  styleUrls: ['./bai-viet-create.component.scss']
})
export class BaiVietCreateComponent implements OnInit {
  public Editor = ClassicEditor;

  baiViet: any = {};
  danhMuc: any = [];
  hienThiHinhAnh: any;
  hienThiHinhAnhNV: any;
  isThemNV: boolean = false;
  baiVietFromData = new FormData();

  constructor(private apiService: ApiService, private sanitizer: DomSanitizer,
    private toastr: ToastrService,
    private baseService: BaseService, private router: Router) { }
  ngOnInit(): void {

    this.baiViet.HienThi = true;
    ClassicEditor
      .create(document.querySelector('#editor'))
      .then()
      .catch();
    this.getDanhMuc();
  }

  public onReady(editor) {
    editor.ui.getEditableElement().parentElement.insertBefore(
      editor.ui.view.toolbar.element,
      editor.ui.getEditableElement()
    );
  }


  getDanhMuc() {
    this.apiService.get(`DanhMucBaiViet/geAlltDanhMuc`).toPromise().then((data) => {
      this.danhMuc = data;
    })
  }
  nhapTenBaiViet() {
    this.baiViet.Alias = this.utf8ConvertJavascript(this.baiViet.Ten);
  }
  chonDanhMuc(event) {
    this.baiViet.DanhMucId = event;
  }

  save() {
    if (!this.baiViet.DanhMucId || !this.baiViet.Ten || !this.baiViet.NoiDung || !this.baiViet.NoiDungNgan || !this.hienThiHinhAnh) {
      this.toastr.error('Lỗi chưa nhập các trường!');
      return;
    }
    if (this.isThemNV) {
      if (!this.baiViet.TenNV || !this.baiViet.NoiDungNV || !this.baiViet.NoiTaoDanhNV || !this.hienThiHinhAnhNV){
        this.toastr.error('Lỗi chưa nhập các trường (nhân vật)!');
      return;
      }
    }
    this.baiVietFromData.append('Ten', this.baiViet.Ten);
    this.baiVietFromData.append('Alias', this.baiViet.Alias);
    this.baiVietFromData.append('NoiDungNgan', this.baiViet.NoiDungNgan);
    this.baiVietFromData.append('NoiDung', this.baiViet.NoiDung);
    this.baiVietFromData.append('DanhMucId', this.baiViet.DanhMucId);
    this.baiVietFromData.append('ThuTuHienThi', this.baiViet.ThuTuHienThi);
    this.baiVietFromData.append('HienThi', this.baiViet.HienThi);

    this.baiVietFromData.append('TenNV', this.baiViet.TenNV);
    this.baiVietFromData.append('NoiDungNV', this.baiViet.NoiDungNV);
    this.baiVietFromData.append('NoiTaoDanhNV', this.baiViet.NoiTaoDanhNV);
    this.baiVietFromData.append('DiemTanBao', this.baiViet.DiemTanBao);
    this.baiVietFromData.append('DiemNguyHiem', this.baiViet.DiemNguyHiem);
    this.baiVietFromData.append('DiemBeNgoai', this.baiViet.DiemBeNgoai);
    this.baseService.create(this.baiVietFromData).toPromise().then((data: any) => {
      this.router.navigate(['bai-viet']);
    }, (error) => {
      console.log(error)
    });
  }
  url: string;
  onSelectFile(event) { // called each time file input changes

    if (event.target.files && event.target.files[0]) {
      var reader = new FileReader();


      reader.readAsDataURL(event.target.files[0]); // read file as data url

      reader.onload = (event) => { // called once readAsDataURL is completed
        this.baiVietFromData.append('HinhAnhBase64', event.target.result.toString().split(',')[1]);
        this.hienThiHinhAnh =
          (this.sanitizer.bypassSecurityTrustResourceUrl(event.target.result.toString()) as any).changingThisBreaksApplicationSecurity;
      }
    }
  }
  onSelectFileNV(event) { // called each time file input changes

    if (event.target.files && event.target.files[0]) {
      var reader = new FileReader();


      reader.readAsDataURL(event.target.files[0]); // read file as data url

      reader.onload = (event) => { // called once readAsDataURL is completed
        this.baiVietFromData.append('HinhAnhBase64NV', event.target.result.toString().split(',')[1]);
        this.hienThiHinhAnhNV =
          (this.sanitizer.bypassSecurityTrustResourceUrl(event.target.result.toString()) as any).changingThisBreaksApplicationSecurity;
      }
    }
  }
  themNhanVat() {
    this.isThemNV = !this.isThemNV;
  }
  utf8ConvertJavascript(obj) {
    var str = obj;
    str = str.toLowerCase();
    str = str.replace(/à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ/g, "a");
    str = str.replace(/è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ/g, "e");
    str = str.replace(/ì|í|ị|ỉ|ĩ/g, "i");
    str = str.replace(/ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ/g, "o");
    str = str.replace(/ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ/g, "u");
    str = str.replace(/ỳ|ý|ỵ|ỷ|ỹ/g, "y");
    str = str.replace(/đ/g, "d");
    str = str.replace(/!|@|%|\^|\*|\(|\)|\+|\=|\<|\>|\?|\/|,|\.|\:|\;|\'| |\"|\&|\#|\[|\]|~|$|_/g, "-");
    /* tìm và thay thế các kí tự đặc biệt trong chuỗi sang kí tự - */
    str = str.replace(/-+-/g, "-"); //thay thế 2- thành 1-
    str = str.replace(/^\-+|\-+$/g, "");

    return str;
  }
}
