/* tslint:disable */
/* eslint-disable */
import { BookingStatus } from './booking-status';
import { ConcertResDto } from './concert-res-dto';
export interface BookingResDto {
  bookingId?: number;
  bookingTime?: string;
  concert?: ConcertResDto;
  status?: BookingStatus;
  userEmail?: null | string;
  userName?: null | string;
}
