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

import { BookingReqDto } from '../models/booking-req-dto';
import { BookingResDto } from '../models/booking-res-dto';

@Injectable({
  providedIn: 'root',
})
export class BookingService extends BaseService {
  constructor(
    config: ApiConfiguration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * Path part for operation bookingGet
   */
  static readonly BookingGetPath = '/Booking';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `bookingGet$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  bookingGet$Plain$Response(params?: {
  },
  context?: HttpContext

): Observable<StrictHttpResponse<Array<BookingResDto>>> {

    const rb = new RequestBuilder(this.rootUrl, BookingService.BookingGetPath, 'get');
    if (params) {
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain',
      context: context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Array<BookingResDto>>;
      })
    );
  }

  /**
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `bookingGet$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  bookingGet$Plain(params?: {
  },
  context?: HttpContext

): Observable<Array<BookingResDto>> {

    return this.bookingGet$Plain$Response(params,context).pipe(
      map((r: StrictHttpResponse<Array<BookingResDto>>) => r.body as Array<BookingResDto>)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `bookingGet$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  bookingGet$Json$Response(params?: {
  },
  context?: HttpContext

): Observable<StrictHttpResponse<Array<BookingResDto>>> {

    const rb = new RequestBuilder(this.rootUrl, BookingService.BookingGetPath, 'get');
    if (params) {
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json',
      context: context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Array<BookingResDto>>;
      })
    );
  }

  /**
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `bookingGet$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  bookingGet$Json(params?: {
  },
  context?: HttpContext

): Observable<Array<BookingResDto>> {

    return this.bookingGet$Json$Response(params,context).pipe(
      map((r: StrictHttpResponse<Array<BookingResDto>>) => r.body as Array<BookingResDto>)
    );
  }

  /**
   * Path part for operation bookingPost
   */
  static readonly BookingPostPath = '/Booking';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `bookingPost$Plain()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  bookingPost$Plain$Response(params?: {
    body?: BookingReqDto
  },
  context?: HttpContext

): Observable<StrictHttpResponse<BookingResDto>> {

    const rb = new RequestBuilder(this.rootUrl, BookingService.BookingPostPath, 'post');
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
        return r as StrictHttpResponse<BookingResDto>;
      })
    );
  }

  /**
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `bookingPost$Plain$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  bookingPost$Plain(params?: {
    body?: BookingReqDto
  },
  context?: HttpContext

): Observable<BookingResDto> {

    return this.bookingPost$Plain$Response(params,context).pipe(
      map((r: StrictHttpResponse<BookingResDto>) => r.body as BookingResDto)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `bookingPost$Json()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  bookingPost$Json$Response(params?: {
    body?: BookingReqDto
  },
  context?: HttpContext

): Observable<StrictHttpResponse<BookingResDto>> {

    const rb = new RequestBuilder(this.rootUrl, BookingService.BookingPostPath, 'post');
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
        return r as StrictHttpResponse<BookingResDto>;
      })
    );
  }

  /**
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `bookingPost$Json$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  bookingPost$Json(params?: {
    body?: BookingReqDto
  },
  context?: HttpContext

): Observable<BookingResDto> {

    return this.bookingPost$Json$Response(params,context).pipe(
      map((r: StrictHttpResponse<BookingResDto>) => r.body as BookingResDto)
    );
  }

}
