import { Component, inject } from '@angular/core';
import { AppRoutingModule } from "../app-routing.module";
import { AddConcertService } from '../auto-refresh.service';
import { ConcertService } from '../api/services';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent {
 private concertService = inject(ConcertService);
  concertCount = 0;

  ngOnInit() {
    this.concertService.concertGet().subscribe({
      next: (response) => {
        this.concertCount = response.length;
      }
    });
  }
}
