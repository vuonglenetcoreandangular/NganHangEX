import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BaiVietComponent } from './components/bai-viet/bai-viet.component';
import { VayNganHangHeaderComponent } from './components/vay-ngan-hang-header/vay-ngan-hang-header.component';
import { VayNganHangFooterComponent } from './components/vay-ngan-hang-footer/vay-ngan-hang-footer.component';
import { TrangChuComponent } from './components/trang-chu/trang-chu.component';
import { HttpClientModule } from '@angular/common/http';
import { DanhMucDetailComponent } from './components/danh-muc-detail/danh-muc-detail.component';
import { SocialLoginModule, SocialAuthServiceConfig } from 'angularx-social-login';
import { GoogleLoginProvider, FacebookLoginProvider } from 'angularx-social-login';
import { TestLoginComponent } from './components/test-login/test-login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    BaiVietComponent,
    VayNganHangHeaderComponent,
    VayNganHangFooterComponent,
    TrangChuComponent,
    DanhMucDetailComponent,
    TestLoginComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    SocialLoginModule
  ],
  providers: [
    {
      provide: 'SocialAuthServiceConfig',
      useValue: {
        autoLogin: false,
        providers: [
          {
            id: GoogleLoginProvider.PROVIDER_ID,
            provider: new GoogleLoginProvider(
              '14967918252-gi5700968sj3hthnhkujlaknlikstj2u.apps.googleusercontent.com'
            )
          },
          {
            id: FacebookLoginProvider.PROVIDER_ID,
            provider: new FacebookLoginProvider('270879031455624')
          }
        ]
      } as SocialAuthServiceConfig,
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
