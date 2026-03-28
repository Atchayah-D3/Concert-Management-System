/* tslint:disable */
/* eslint-disable */
import { BookingStatus } from './booking-status';
export interface HallBookingDto {
  fromDateTime?: string;
  hallBookingId?: null | number;
  hallName?: null | string;
  price?: null | number;
  status?: BookingStatus;
  toDateTime?: string;
  userEmail?: null | string;
}
