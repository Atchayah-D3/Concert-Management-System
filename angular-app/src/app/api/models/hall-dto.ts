/* tslint:disable */
/* eslint-disable */
import { HallBookingDto } from './hall-booking-dto';
export interface HallDto {
  bookings?: null | Array<HallBookingDto>;
  capacity?: number;
  hallId?: number;
  hallName?: null | string;
  location?: null | string;
  ownerId?: number;
  pricePerHour?: number;
}
