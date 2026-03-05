/* tslint:disable */
/* eslint-disable */
import { ConcertSpecResDto } from './concert-spec-res-dto';
export interface ConcertResDto {
  concertId?: number;
  concertName: null | string;
  concertSpec?: ConcertSpecResDto;
  creatorId?: number;
}
