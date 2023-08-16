import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeeManagementComponent } from './components/employee-management/employee-management.component';
import { ClientManagementComponent } from './components/client-management/client-management.component';

const routes: Routes = [
  { path: 'gestion-salaries', component: EmployeeManagementComponent },
  { path: 'gestion-clients', component: ClientManagementComponent },
  { path: '', redirectTo: '/gestion-salaries', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
