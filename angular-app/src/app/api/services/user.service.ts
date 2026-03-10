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

import { UserReqDto } from '../models/user-req-dto';
import { UserResDto } from '../models/user-res-dto';

@Injectable({
  providedIn: 'root',
})
export class UserService extends BaseService {
  constructor(
    config: ApiConfiguration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * Path part for operation userGet
   */
  static readonly UserGetPath = '/User';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `userGet$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  userGet$Plain$Response(params?: {
    uuid?: string;
  },
  context?: HttpContext

): Observable<StrictHttpResponse<number>> {

    const rb = new RequestBuilder(this.rootUrl, UserService.UserGetPath, 'get');
    if (params) {
      rb.query('uuid', params.uuid, {});
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain',
      context: context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return (r as HttpResponse<any>).clone({ body: parseFloat(String((r as HttpResponse<any>).body)) }) as StrictHttpResponse<number>;
      })
    );
  }

  /**
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `userGet$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  userGet$Plain(params?: {
    uuid?: string;
  },
  context?: HttpContext

): Observable<number> {

    return this.userGet$Plain$Response(params,context).pipe(
      map((r: StrictHttpResponse<number>) => r.body as number)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `userGet$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  userGet$Json$Response(params?: {
    uuid?: string;
  },
  context?: HttpContext

): Observable<StrictHttpResponse<number>> {

    const rb = new RequestBuilder(this.rootUrl, UserService.UserGetPath, 'get');
    if (params) {
      rb.query('uuid', params.uuid, {});
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json',
      context: context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return (r as HttpResponse<any>).clone({ body: parseFloat(String((r as HttpResponse<any>).body)) }) as StrictHttpResponse<number>;
      })
    );
  }

  /**
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `userGet$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  userGet$Json(params?: {
    uuid?: string;
  },
  context?: HttpContext

): Observable<number> {

    return this.userGet$Json$Response(params,context).pipe(
      map((r: StrictHttpResponse<number>) => r.body as number)
    );
  }

  /**
   * Path part for operation userPost
   */
  static readonly UserPostPath = '/User';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `userPost$Plain()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  userPost$Plain$Response(params?: {
    body?: UserReqDto
  },
  context?: HttpContext

): Observable<StrictHttpResponse<UserResDto>> {

    const rb = new RequestBuilder(this.rootUrl, UserService.UserPostPath, 'post');
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
        return r as StrictHttpResponse<UserResDto>;
      })
    );
  }

  /**
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `userPost$Plain$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  userPost$Plain(params?: {
    body?: UserReqDto
  },
  context?: HttpContext

): Observable<UserResDto> {

    return this.userPost$Plain$Response(params,context).pipe(
      map((r: StrictHttpResponse<UserResDto>) => r.body as UserResDto)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `userPost$Json()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  userPost$Json$Response(params?: {
    body?: UserReqDto
  },
  context?: HttpContext

): Observable<StrictHttpResponse<UserResDto>> {

    const rb = new RequestBuilder(this.rootUrl, UserService.UserPostPath, 'post');
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
        return r as StrictHttpResponse<UserResDto>;
      })
    );
  }

  /**
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `userPost$Json$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  userPost$Json(params?: {
    body?: UserReqDto
  },
  context?: HttpContext

): Observable<UserResDto> {

    return this.userPost$Json$Response(params,context).pipe(
      map((r: StrictHttpResponse<UserResDto>) => r.body as UserResDto)
    );
  }

  /**
   * Path part for operation userUserIdGet
   */
  static readonly UserUserIdGetPath = '/User/{userId}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `userUserIdGet$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  userUserIdGet$Plain$Response(params: {
    userId: number;
  },
  context?: HttpContext

): Observable<StrictHttpResponse<UserResDto>> {

    const rb = new RequestBuilder(this.rootUrl, UserService.UserUserIdGetPath, 'get');
    if (params) {
      rb.path('userId', params.userId, {});
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain',
      context: context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<UserResDto>;
      })
    );
  }

  /**
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `userUserIdGet$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  userUserIdGet$Plain(params: {
    userId: number;
  },
  context?: HttpContext

): Observable<UserResDto> {

    return this.userUserIdGet$Plain$Response(params,context).pipe(
      map((r: StrictHttpResponse<UserResDto>) => r.body as UserResDto)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `userUserIdGet$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  userUserIdGet$Json$Response(params: {
    userId: number;
  },
  context?: HttpContext

): Observable<StrictHttpResponse<UserResDto>> {

    const rb = new RequestBuilder(this.rootUrl, UserService.UserUserIdGetPath, 'get');
    if (params) {
      rb.path('userId', params.userId, {});
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json',
      context: context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<UserResDto>;
      })
    );
  }

  /**
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `userUserIdGet$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  userUserIdGet$Json(params: {
    userId: number;
  },
  context?: HttpContext

): Observable<UserResDto> {

    return this.userUserIdGet$Json$Response(params,context).pipe(
      map((r: StrictHttpResponse<UserResDto>) => r.body as UserResDto)
    );
  }

}
