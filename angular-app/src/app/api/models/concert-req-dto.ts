/* tslint:disable */
/* eslint-disable */
import { ConcertSpecReqDto } from './concert-spec-req-dto';
export interface ConcertReqDto {
  concertName: null | string;
  concertSpec?: ConcertSpecReqDto;
}
