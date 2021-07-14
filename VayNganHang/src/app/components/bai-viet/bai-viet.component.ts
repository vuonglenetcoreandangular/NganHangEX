import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-bai-viet',
  templateUrl: './bai-viet.component.html',
  styleUrls: ['./bai-viet.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class BaiVietComponent implements OnInit {
  baiViet: any = {};
  diemTanBao: any = 50;
  diemNguyHiem: any = 50;
  diemBeNgoai: any = 50;
  constructor(private apiService: ApiService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    let baiVietId = this.route.snapshot.params['id'];
    this.getBaiVietDetail(baiVietId);
  }

  getBaiVietDetail(baiVietId) {
    this.apiService.get(`BaiVietPortal/GetBaiVietDetail/${baiVietId}`).toPromise().then((data) => {
      this.baiViet = data;
    })
  }


  rangeDiemTanBao(e) {
    this.diemTanBao = e;
  }

  rangeDiemNguyHiem(e) {
    this.diemNguyHiem = e;
  }

  rangeDiemBeNgoai(e) {
    this.diemBeNgoai = e;
  }


}


