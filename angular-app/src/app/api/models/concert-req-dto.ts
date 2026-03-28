/* tslint:disable */
/* eslint-disable */
import { ConcertSpecReqDto } from './concert-spec-req-dto';
import { HallBookingReqDto } from './hall-booking-req-dto';
export interface ConcertReqDto {
  concertName: null | string;
  concertSpec?: ConcertSpecReqDto;
  customHall?: null | string;
  hallBookingReq?: HallBookingReqDto;
}
