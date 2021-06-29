import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BaiVietListComponent } from './bai-viet-list/bai-viet-list.component';
import { BaiVietCreateComponent } from './bai-viet-create/bai-viet-create.component';
import { BaiVietUpdateComponent } from './bai-viet-update/bai-viet-update.component';

const routes: Routes = [
  {
    path: '',
    component: BaiVietListComponent,
    data: {
      title: 'bai-viet'
    }  

  },
  {
    path:'them',
    component: BaiVietCreateComponent,
    data: {
      title: 'them-bai-viet'
    },
    
  },
  {
    path:'chinh-sua/:id',
    component: BaiVietUpdateComponent,
    data: {
      title: 'chinh-sua-bai-viet'
    },
    
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BaiVietRoutingModule { }
