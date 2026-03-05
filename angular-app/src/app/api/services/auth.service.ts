/* tslint:disable */
/* eslint-disable */
import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse, HttpContext } from '@angular/common/http';
import { BaseService } from '../base-service';
import { ApiConfiguration } from '../api-configuration';
import { StrictHttpResponse } from '../strict-http-response';
import { RequestBuilder } from '../request-builder';
import { Observable } from 'rxjs';
import { map, filter } from 'rxjs/operators';

import { LoginResDto } from '../models/login-res-dto';
import { UserReqDto } from '../models/user-req-dto';

@Injectable({
  providedIn: 'root',
})
export class AuthService extends BaseService {
  constructor(
    config: ApiConfiguration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * Path part for operation authLoginPost
   */
  static readonly AuthLoginPostPath = '/Auth/login';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `authLoginPost$Plain()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  authLoginPost$Plain$Response(params?: {
    body?: UserReqDto
  },
  context?: HttpContext

): Observable<StrictHttpResponse<LoginResDto>> {

    const rb = new RequestBuilder(this.rootUrl, AuthService.AuthLoginPostPath, 'post');
    if (params) {
      rb.body(params.body, 'application/*+json');
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain',
      context: context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<LoginResDto>;
      })
    );
  }

  /**
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `authLoginPost$Plain$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  authLoginPost$Plain(params?: {
    body?: UserReqDto
  },
  context?: HttpContext

): Observable<LoginResDto> {

    return this.authLoginPost$Plain$Response(params,context).pipe(
      map((r: StrictHttpResponse<LoginResDto>) => r.body as LoginResDto)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `authLoginPost$Json()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  authLoginPost$Json$Response(params?: {
    body?: UserReqDto
  },
  context?: HttpContext

): Observable<StrictHttpResponse<LoginResDto>> {

    const rb = new RequestBuilder(this.rootUrl, AuthService.AuthLoginPostPath, 'post');
    if (params) {
      rb.body(params.body, 'application/*+json');
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json',
      context: context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<LoginResDto>;
      })
    );
  }

  /**
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `authLoginPost$Json$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  authLoginPost$Json(params?: {
    body?: UserReqDto
  },
  context?: HttpContext

): Observable<LoginResDto> {

    return this.authLoginPost$Json$Response(params,context).pipe(
      map((r: StrictHttpResponse<LoginResDto>) => r.body as LoginResDto)
    );
  }

  /**
   * Path part for operation authRegisterPost
   */
  static readonly AuthRegisterPostPath = '/Auth/register';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `authRegisterPost$Plain()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  authRegisterPost$Plain$Response(params?: {
    body?: UserReqDto
  },
  context?: HttpContext

): Observable<StrictHttpResponse<LoginResDto>> {

    const rb = new RequestBuilder(this.rootUrl, AuthService.AuthRegisterPostPath, 'post');
    if (params) {
      rb.body(params.body, 'application/*+json');
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain',
      context: context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<LoginResDto>;
      })
    );
  }

  /**
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `authRegisterPost$Plain$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  authRegisterPost$Plain(params?: {
    body?: UserReqDto
  },
  context?: HttpContext

): Observable<LoginResDto> {

    return this.authRegisterPost$Plain$Response(params,context).pipe(
      map((r: StrictHttpResponse<LoginResDto>) => r.body as LoginResDto)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `authRegisterPost$Json()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  authRegisterPost$Json$Response(params?: {
    body?: UserReqDto
  },
  context?: HttpContext

): Observable<StrictHttpResponse<LoginResDto>> {

    const rb = new RequestBuilder(this.rootUrl, AuthService.AuthRegisterPostPath, 'post');
    if (params) {
      rb.body(params.body, 'application/*+json');
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json',
      context: context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<LoginResDto>;
      })
    );
  }

  /**
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `authRegisterPost$Json$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  authRegisterPost$Json(params?: {
    body?: UserReqDto
  },
  context?: HttpContext

): Observable<LoginResDto> {

    return this.authRegisterPost$Json$Response(params,context).pipe(
      map((r: StrictHttpResponse<LoginResDto>) => r.body as LoginResDto)
    );
  }

}
