import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiService } from '../../../services/api.service';
import { BaseService } from '../../../services/base.service';
import { BaiVietService } from '../bai-viet.service';
import * as ClassicEditor from '@ckeditor/ckeditor5-build-classic';

@Component({
  selector: 'app-bai-viet-update',
  templateUrl: './bai-viet-update.component.html',
  styleUrls: ['./bai-viet-update.component.scss']
})
export class BaiVietUpdateComponent implements OnInit {
  public Editor = ClassicEditor;
  baiViet: any ={};
  danhMuc: any =[];
  constructor(private route: ActivatedRoute, private baiVietService: BaiVietService,
    private apiService: ApiService, private baseService : BaseService,
    private router: Router) { }

  ngOnInit(): void {
    //let id = this.route.snapshot.params['id'];
    this.getById(this.route.snapshot.params['id']);
    this.getDanhMuc();
  }

  public onReady(editor) {
    editor.ui.getEditableElement().parentElement.insertBefore(
      editor.ui.view.toolbar.element,
      editor.ui.getEditableElement()
    );
  }

  getById(id: number) {
    this.baiVietService.getById(id).toPromise().then((data) => {
      this.baiViet = data;
    }, (error) => {
      console.log(error)

    });
  }
  getDanhMuc() {
    this.apiService.get(`DanhMucBaiViet/geAlltDanhMuc`).toPromise().then((data) => {
      this.danhMuc = data;
    })
  }
  nhapTenBaiViet(){
    this.baiViet.Alias = this.utf8ConvertJavascript(this.baiViet.Ten);
  }
  chonDanhMuc(event) {
    this.baiViet.DanhMucId = event;
  }
  

  save() {

    let baiVietFromData = new FormData();
    baiVietFromData.append('Id', this.baiViet.Id)
    baiVietFromData.append('Ten', this.baiViet.Ten)
    baiVietFromData.append('Alias', this.baiViet.Alias)
    baiVietFromData.append('Logo', this.baiViet.Logo)
    baiVietFromData.append('NoiDungNgan', this.baiViet.NoiDungNgan)
    baiVietFromData.append('NoiDungTomTat', this.baiViet.NoiDungTomTat)
    baiVietFromData.append('NoiDung', this.baiViet.NoiDung)
    baiVietFromData.append('DanhMucId', this.baiViet.DanhMucId)
    baiVietFromData.append('ThuTuHienThi', this.baiViet.ThuTuHienThi)
    baiVietFromData.append('HienThi', this.baiViet.HienThi)

    this.baseService.update(baiVietFromData).toPromise().then((data: any) => {
      this.router.navigate(['bai-viet']);
    }, (error) => {
      console.log(error)
    });
  }

  utf8ConvertJavascript(obj)
  {
      var str = obj;
      str = str.toLowerCase();
      str = str.replace(/??|??|???|???|??|??|???|???|???|???|???|??|???|???|???|???|???/g, "a");
      str = str.replace(/??|??|???|???|???|??|???|???|???|???|???/g, "e");
      str = str.replace(/??|??|???|???|??/g, "i");
      str = str.replace(/??|??|???|???|??|??|???|???|???|???|???|??|???|???|???|???|???/g, "o");
      str = str.replace(/??|??|???|???|??|??|???|???|???|???|???/g, "u");
      str = str.replace(/???|??|???|???|???/g, "y");
      str = str.replace(/??/g, "d");
      str= str.replace(/!|@|%|\^|\*|\(|\)|\+|\=|\<|\>|\?|\/|,|\.|\:|\;|\'| |\"|\&|\#|\[|\]|~|$|_/g,"-");
      /* t??m v?? thay th??? c??c k?? t??? ?????c bi???t trong chu???i sang k?? t??? - */
      str= str.replace(/-+-/g,"-"); //thay th??? 2- th??nh 1-
      str = str.replace(/^\-+|\-+$/g, "");
  
      return str;
  }

}