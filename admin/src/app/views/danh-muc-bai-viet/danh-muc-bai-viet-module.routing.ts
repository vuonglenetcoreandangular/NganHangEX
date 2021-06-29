import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DanhMucBaiVietCreateComponent } from './danh-muc-bai-viet-create/danh-muc-bai-viet-create.component';
import { DanhMucBaiVietListComponent } from './danh-muc-bai-viet-list/danh-muc-bai-viet-list.component';
import { DanhMucBaiVietUpdateComponent } from './danh-muc-bai-viet-update/danh-muc-bai-viet-update.component';


const routes: Routes = [
  {
    path: '',
    component: DanhMucBaiVietListComponent,
    data: {
      title: 'danh-muc-bai-viet'
    }  

  },
  {
    path:'them',
    component: DanhMucBaiVietCreateComponent,
    data: {
      title: 'them-danh-muc-bai-viet'
    },
    
  },
  {
    path:'chinh-sua/:id',
    component: DanhMucBaiVietUpdateComponent,
    data: {
      title: 'chinh-sua-danh-muc-bai-viet'
    },
    
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DanhMucBaiVietRoutingModule { }
