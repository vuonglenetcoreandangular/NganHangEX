import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
// import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { FacebookLoginProvider, GoogleLoginProvider, SocialAuthService, SocialUser } from 'angularx-social-login';
import { ApiService } from 'src/app/services/api.service';
import { LoginPopupComponent } from './login-popup/login-popup.component';

@Component({
  selector: 'app-vay-ngan-hang-header',
  templateUrl: './vay-ngan-hang-header.component.html',
  styleUrls: ['./vay-ngan-hang-header.component.css']
})
export class VayNganHangHeaderComponent implements OnInit {
  danhMucMeNus: any = [];
  user: SocialUser;
  loggedIn: boolean;
  invalidLogin: boolean;
  constructor(private apiService: ApiService, private router: Router, private authService: SocialAuthService) { }

  ngOnInit(): void {
    this.getDanhMucMenu();
    this.authService.authState.subscribe((user) => {
      this.user = user;
      this.loggedIn = (user != null);


      console.log('x', this.user)
      console.log('y', this.loggedIn)
    });

  }

  getDanhMucMenu() {
    this.apiService.get(`DanhMucPortal/GetDanhMucHienThiMenu`).toPromise().then((data) => {
      this.danhMucMeNus = data;
    })
  }
  onlick() {
    this.router.navigate([`danh-muc/14`]);
  }


  signInWithGoogle(): void {
    this.authService.signIn(GoogleLoginProvider.PROVIDER_ID).then((data) => {
      if (data) {
        localStorage.setItem('account_g', this.user.id);
      }
    });
    console.log('2', this.user);
  }

  signInWithFB(): void {
    this.authService.signIn(FacebookLoginProvider.PROVIDER_ID).then((data) => {
      if (data) {
        localStorage.setItem('account_f', this.user.id);
      }
    });
    console.log('4', this.user);
  }

  signOut(): void {
    this.authService.signOut().then((data) => {
      localStorage.clear();
    });

  }

  refreshToken(): void {
    this.authService.refreshAuthToken(GoogleLoginProvider.PROVIDER_ID);
  }


  login(form: NgForm) {
    const credentials = {
      'username': form.value.username,
      'password': form.value.password
    }

    this.apiService.post(`DocGia/Login`, credentials).toPromise().then((data: any) => {
      console.log(data);
      const token = (<string>data.tokenString);
      //localStorage.setItem("jwt",token);

      localStorage.setItem("jwt", data.tokenString);
    });
  }

  // dangNhap() {
  //   this.dialog.open(LoginPopupComponent, {
  //     disableClose: false,
  //     width: "800px",
  //     data: {
  //       Title: "Xác nhận",
  //       Message: "view-order"
  //     },
  //   }).afterClosed(

  //   ).subscribe((result) => {
  //     if (result == "Yes") {

  //     }
  //   });
  // }

}
