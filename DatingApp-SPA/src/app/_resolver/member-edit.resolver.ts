import { User } from '../_models/user';
import { Injectable} from '@angular/core';
import { UserService } from '../_services/user.service';
import { Resolve, Router, ActivatedRouteSnapshot, RouterStateSnapshot} from '@angular/router';
import { AlertifyService } from '../_services/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AuthService } from '../_services/auth.service';

@Injectable()
export class MemberEditResolver implements Resolve<User> {
  constructor(
    private userService: UserService,
    private router: Router,
    private alertifyService: AlertifyService,
    private authService: AuthService,
  ){}

  resolve(route: ActivatedRouteSnapshot): Observable<User>
  {
    return this.userService.getUser(this.authService.decodedToken.nameid).pipe(
        catchError(error => {
            this.alertifyService.error("Problem retrieving your data");
            this.router.navigate(['/members']);
            return of(null);
        })
    );
  }
}