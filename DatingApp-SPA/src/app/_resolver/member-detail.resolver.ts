import { User } from '../_models/user';
import { Injectable} from '@angular/core';
import { UserService } from '../_services/user.service';
import { Resolve, Router, ActivatedRouteSnapshot, RouterStateSnapshot} from '@angular/router';
import { AlertifyService } from '../_services/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable()
export class MemberDetailResolver implements Resolve<User> {
  constructor(
    private userService: UserService,
    private router: Router,
    private alertifyService: AlertifyService
  ){}

  resolve(route: ActivatedRouteSnapshot): Observable<User>
  {
    return this.userService.getUser(route.params['id']).pipe(
        catchError(error => {
            this.alertifyService.error("Problem retrieving data");
            this.router.navigate(['/members']);
            return of(null);
        })
    );
  }
}
