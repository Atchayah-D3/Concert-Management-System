/* tslint:disable */
/* eslint-disable */
import { BookingResDto } from './booking-res-dto';
import { ConcertResDto } from './concert-res-dto';
import { UserRole } from './user-role';
export interface UserResDto {
  bookings?: null | Array<BookingResDto>;
  concerts?: null | Array<ConcertResDto>;
  email: null | string;
  role?: UserRole;
  userId?: number;
  userName?: null | string;
}
