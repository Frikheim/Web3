import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { Lagre} from './lagre/lagre';
import { Liste } from './faq/faq';
import { Endre } from './endre/endre';

const appRoots: Routes = [
  { path: 'faq', component: Liste },
  { path: 'lagre', component: Lagre },
  { path: 'endre/:id', component: Endre, },
  { path: '', redirectTo: 'faq', pathMatch: 'full' }
]

@NgModule({
  imports: [
    RouterModule.forRoot(appRoots)
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }
