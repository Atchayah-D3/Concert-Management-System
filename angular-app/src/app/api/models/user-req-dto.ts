/* tslint:disable */
/* eslint-disable */
import { UserRole } from './user-role';
export interface UserReqDto {
  email: null | string;
  password?: null | string;
  role?: UserRole;
  userName?: null | string;
}
