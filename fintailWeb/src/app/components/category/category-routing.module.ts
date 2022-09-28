import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CategoryFormComponent } from './category-form/category-form.component';
import { CategorylistComponent } from './categorylist/categorylist.component';

const routes: Routes = [
  { path: '', component: CategorylistComponent },
  { path: 'new', component: CategoryFormComponent },
  { path: ':id', component: CategoryFormComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CategoryRoutingModule {}
