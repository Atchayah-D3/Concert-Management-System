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

import { HallBookingDto } from '../models/hall-booking-dto';

@Injectable({
  providedIn: 'root',
})
export class HallBookingService extends BaseService {
  constructor(
    config: ApiConfiguration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * Path part for operation hallBookingHallIdPost
   */
  static readonly HallBookingHallIdPostPath = '/HallBooking/{hallId}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `hallBookingHallIdPost$Plain()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  hallBookingHallIdPost$Plain$Response(params: {
    hallId: number;
    body?: HallBookingDto
  },
  context?: HttpContext

): Observable<StrictHttpResponse<HallBookingDto>> {

    const rb = new RequestBuilder(this.rootUrl, HallBookingService.HallBookingHallIdPostPath, 'post');
    if (params) {
      rb.path('hallId', params.hallId, {});
      rb.body(params.body, 'application/*+json');
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain',
      context: context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<HallBookingDto>;
      })
    );
  }

  /**
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `hallBookingHallIdPost$Plain$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  hallBookingHallIdPost$Plain(params: {
    hallId: number;
    body?: HallBookingDto
  },
  context?: HttpContext

): Observable<HallBookingDto> {

    return this.hallBookingHallIdPost$Plain$Response(params,context).pipe(
      map((r: StrictHttpResponse<HallBookingDto>) => r.body as HallBookingDto)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `hallBookingHallIdPost$Json()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  hallBookingHallIdPost$Json$Response(params: {
    hallId: number;
    body?: HallBookingDto
  },
  context?: HttpContext

): Observable<StrictHttpResponse<HallBookingDto>> {

    const rb = new RequestBuilder(this.rootUrl, HallBookingService.HallBookingHallIdPostPath, 'post');
    if (params) {
      rb.path('hallId', params.hallId, {});
      rb.body(params.body, 'application/*+json');
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json',
      context: context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<HallBookingDto>;
      })
    );
  }

  /**
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `hallBookingHallIdPost$Json$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  hallBookingHallIdPost$Json(params: {
    hallId: number;
    body?: HallBookingDto
  },
  context?: HttpContext

): Observable<HallBookingDto> {

    return this.hallBookingHallIdPost$Json$Response(params,context).pipe(
      map((r: StrictHttpResponse<HallBookingDto>) => r.body as HallBookingDto)
    );
  }

  /**
   * Path part for operation hallBookingHallHallIdGet
   */
  static readonly HallBookingHallHallIdGetPath = '/HallBooking/hall/{hallId}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `hallBookingHallHallIdGet$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  hallBookingHallHallIdGet$Plain$Response(params: {
    hallId: number;
  },
  context?: HttpContext

): Observable<StrictHttpResponse<HallBookingDto>> {

    const rb = new RequestBuilder(this.rootUrl, HallBookingService.HallBookingHallHallIdGetPath, 'get');
    if (params) {
      rb.path('hallId', params.hallId, {});
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain',
      context: context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<HallBookingDto>;
      })
    );
  }

  /**
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `hallBookingHallHallIdGet$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  hallBookingHallHallIdGet$Plain(params: {
    hallId: number;
  },
  context?: HttpContext

): Observable<HallBookingDto> {

    return this.hallBookingHallHallIdGet$Plain$Response(params,context).pipe(
      map((r: StrictHttpResponse<HallBookingDto>) => r.body as HallBookingDto)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `hallBookingHallHallIdGet$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  hallBookingHallHallIdGet$Json$Response(params: {
    hallId: number;
  },
  context?: HttpContext

): Observable<StrictHttpResponse<HallBookingDto>> {

    const rb = new RequestBuilder(this.rootUrl, HallBookingService.HallBookingHallHallIdGetPath, 'get');
    if (params) {
      rb.path('hallId', params.hallId, {});
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json',
      context: context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<HallBookingDto>;
      })
    );
  }

  /**
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `hallBookingHallHallIdGet$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  hallBookingHallHallIdGet$Json(params: {
    hallId: number;
  },
  context?: HttpContext

): Observable<HallBookingDto> {

    return this.hallBookingHallHallIdGet$Json$Response(params,context).pipe(
      map((r: StrictHttpResponse<HallBookingDto>) => r.body as HallBookingDto)
    );
  }

  /**
   * Path part for operation hallBookingBookingIdDelete
   */
  static readonly HallBookingBookingIdDeletePath = '/HallBooking/{bookingId}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `hallBookingBookingIdDelete$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  hallBookingBookingIdDelete$Plain$Response(params: {
    bookingId: number;
  },
  context?: HttpContext

): Observable<StrictHttpResponse<HallBookingDto>> {

    const rb = new RequestBuilder(this.rootUrl, HallBookingService.HallBookingBookingIdDeletePath, 'delete');
    if (params) {
      rb.path('bookingId', params.bookingId, {});
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain',
      context: context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<HallBookingDto>;
      })
    );
  }

  /**
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `hallBookingBookingIdDelete$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  hallBookingBookingIdDelete$Plain(params: {
    bookingId: number;
  },
  context?: HttpContext

): Observable<HallBookingDto> {

    return this.hallBookingBookingIdDelete$Plain$Response(params,context).pipe(
      map((r: StrictHttpResponse<HallBookingDto>) => r.body as HallBookingDto)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `hallBookingBookingIdDelete$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  hallBookingBookingIdDelete$Json$Response(params: {
    bookingId: number;
  },
  context?: HttpContext

): Observable<StrictHttpResponse<HallBookingDto>> {

    const rb = new RequestBuilder(this.rootUrl, HallBookingService.HallBookingBookingIdDeletePath, 'delete');
    if (params) {
      rb.path('bookingId', params.bookingId, {});
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json',
      context: context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<HallBookingDto>;
      })
    );
  }

  /**
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `hallBookingBookingIdDelete$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  hallBookingBookingIdDelete$Json(params: {
    bookingId: number;
  },
  context?: HttpContext

): Observable<HallBookingDto> {

    return this.hallBookingBookingIdDelete$Json$Response(params,context).pipe(
      map((r: StrictHttpResponse<HallBookingDto>) => r.body as HallBookingDto)
    );
  }

}
