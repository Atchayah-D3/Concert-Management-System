/* tslint:disable */
/* eslint-disable */
import { ConcertSpecDto } from './concert-spec-dto';
import { HallBookingDto } from './hall-booking-dto';
export interface ConcertResDto {
  concertId?: number;
  concertName: null | string;
  concertSpec?: ConcertSpecDto;
  creatorId?: number;
  customHall?: null | string;
  hallBookings?: null | Array<HallBookingDto>;
  hallName?: null | string;
}
