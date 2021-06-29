import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ApiService } from '../../../services/api.service';
import { BaseService } from '../../../services/base.service';
import { DanhMucBaiVetService } from '../danh-muc-bai-viet.service';

@Component({
  selector: 'app-danh-muc-bai-viet-update',
  templateUrl: './danh-muc-bai-viet-update.component.html',
  styleUrls: ['./danh-muc-bai-viet-update.component.scss']
})
export class DanhMucBaiVietUpdateComponent implements OnInit {
  danhMucBaiViet: any ={};
  danhMucCha: any =[]
  constructor(private apiService: ApiService, private danhMucBaiVietService : DanhMucBaiVetService,
    private baseService : BaseService, private route : ActivatedRoute) { }

  ngOnInit(): void {
    //let id = this.route.snapshot.params['id'];
    this.getById(this.route.snapshot.params['id']);
    this.getDanhMucCha();
  }


  getById(id: number) {
    this.danhMucBaiVietService.getById(id).toPromise().then((data) => {
      this.danhMucBaiViet = data;
      console.log(this.danhMucBaiViet)
    }, (error) => {
      console.log(error)

    });
  }

  getDanhMucCha() {
    this.apiService.get(`DanhMucBaiViet/getDanhMucCha`).toPromise().then((data) => {
      console.log('222', data);
      this.danhMucCha = data;
    })
  }
  chonDanhMucCha(event){
    this.danhMucBaiViet.DanhMucChaId = event;
  }
  save() {    
    if(!this.danhMucBaiViet.Ten || !this.danhMucBaiViet.DanhMucChaId){
      return;
    }
    // console.log('post',this.danhMucBaiViet)
    // this.danhMucBaiVietService.create(this.danhMucBaiViet).toPromise().

    let danhMucBaiVietFromData = new FormData();
    danhMucBaiVietFromData.append('Id', this.danhMucBaiViet.Id)
    danhMucBaiVietFromData.append('Ten', this.danhMucBaiViet.Ten)
    danhMucBaiVietFromData.append('Alias', this.danhMucBaiViet.Alias)
    danhMucBaiVietFromData.append('Logo', this.danhMucBaiViet.Logo)
    danhMucBaiVietFromData.append('DanhMucChaId', this.danhMucBaiViet.DanhMucChaId)


    this.baseService.update(danhMucBaiVietFromData).toPromise().then((data: any) => {
      console.log('z1zz', data)
    }, (error) => {
      console.log(error)
    });
  }
}
