import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { ContentRoutingModule } from './modules/content/content-routing.module';

const routes: Routes = [
  { path: 'books', loadChildren: () => import('./modules/content/content.module').then(m => m.ContentModule) },
  { path: '', redirectTo: '/books', pathMatch: 'full' },
  { path: '**', redirectTo: '/books' }
];

@NgModule({
  imports: [
    RouterModule.forChild(routes),
    ContentRoutingModule
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
