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

import { ConcertSpecReqDto } from '../models/concert-spec-req-dto';
import { ConcertSpecResDto } from '../models/concert-spec-res-dto';

@Injectable({
  providedIn: 'root',
})
export class ConcertSpecService extends BaseService {
  constructor(
    config: ApiConfiguration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * Path part for operation concertSpecPost
   */
  static readonly ConcertSpecPostPath = '/ConcertSpec';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `concertSpecPost$Plain()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  concertSpecPost$Plain$Response(params?: {
    body?: ConcertSpecReqDto
  },
  context?: HttpContext

): Observable<StrictHttpResponse<ConcertSpecResDto>> {

    const rb = new RequestBuilder(this.rootUrl, ConcertSpecService.ConcertSpecPostPath, 'post');
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
        return r as StrictHttpResponse<ConcertSpecResDto>;
      })
    );
  }

  /**
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `concertSpecPost$Plain$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  concertSpecPost$Plain(params?: {
    body?: ConcertSpecReqDto
  },
  context?: HttpContext

): Observable<ConcertSpecResDto> {

    return this.concertSpecPost$Plain$Response(params,context).pipe(
      map((r: StrictHttpResponse<ConcertSpecResDto>) => r.body as ConcertSpecResDto)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `concertSpecPost$Json()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  concertSpecPost$Json$Response(params?: {
    body?: ConcertSpecReqDto
  },
  context?: HttpContext

): Observable<StrictHttpResponse<ConcertSpecResDto>> {

    const rb = new RequestBuilder(this.rootUrl, ConcertSpecService.ConcertSpecPostPath, 'post');
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
        return r as StrictHttpResponse<ConcertSpecResDto>;
      })
    );
  }

  /**
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `concertSpecPost$Json$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  concertSpecPost$Json(params?: {
    body?: ConcertSpecReqDto
  },
  context?: HttpContext

): Observable<ConcertSpecResDto> {

    return this.concertSpecPost$Json$Response(params,context).pipe(
      map((r: StrictHttpResponse<ConcertSpecResDto>) => r.body as ConcertSpecResDto)
    );
  }

  /**
   * Path part for operation concertSpecConcertSpecIdGet
   */
  static readonly ConcertSpecConcertSpecIdGetPath = '/ConcertSpec/{concertSpecId}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `concertSpecConcertSpecIdGet$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  concertSpecConcertSpecIdGet$Plain$Response(params: {
    concertSpecId: number;
  },
  context?: HttpContext

): Observable<StrictHttpResponse<ConcertSpecResDto>> {

    const rb = new RequestBuilder(this.rootUrl, ConcertSpecService.ConcertSpecConcertSpecIdGetPath, 'get');
    if (params) {
      rb.path('concertSpecId', params.concertSpecId, {});
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain',
      context: context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<ConcertSpecResDto>;
      })
    );
  }

  /**
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `concertSpecConcertSpecIdGet$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  concertSpecConcertSpecIdGet$Plain(params: {
    concertSpecId: number;
  },
  context?: HttpContext

): Observable<ConcertSpecResDto> {

    return this.concertSpecConcertSpecIdGet$Plain$Response(params,context).pipe(
      map((r: StrictHttpResponse<ConcertSpecResDto>) => r.body as ConcertSpecResDto)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `concertSpecConcertSpecIdGet$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  concertSpecConcertSpecIdGet$Json$Response(params: {
    concertSpecId: number;
  },
  context?: HttpContext

): Observable<StrictHttpResponse<ConcertSpecResDto>> {

    const rb = new RequestBuilder(this.rootUrl, ConcertSpecService.ConcertSpecConcertSpecIdGetPath, 'get');
    if (params) {
      rb.path('concertSpecId', params.concertSpecId, {});
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json',
      context: context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<ConcertSpecResDto>;
      })
    );
  }

  /**
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `concertSpecConcertSpecIdGet$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  concertSpecConcertSpecIdGet$Json(params: {
    concertSpecId: number;
  },
  context?: HttpContext

): Observable<ConcertSpecResDto> {

    return this.concertSpecConcertSpecIdGet$Json$Response(params,context).pipe(
      map((r: StrictHttpResponse<ConcertSpecResDto>) => r.body as ConcertSpecResDto)
    );
  }

  /**
   * Path part for operation concertSpecConcertSpecIdPut
   */
  static readonly ConcertSpecConcertSpecIdPutPath = '/ConcertSpec/{concertSpecId}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `concertSpecConcertSpecIdPut()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  concertSpecConcertSpecIdPut$Response(params: {
    concertSpecId: number;
    body?: ConcertSpecReqDto
  },
  context?: HttpContext

): Observable<StrictHttpResponse<void>> {

    const rb = new RequestBuilder(this.rootUrl, ConcertSpecService.ConcertSpecConcertSpecIdPutPath, 'put');
    if (params) {
      rb.path('concertSpecId', params.concertSpecId, {});
      rb.body(params.body, 'application/*+json');
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: '*/*',
      context: context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return (r as HttpResponse<any>).clone({ body: undefined }) as StrictHttpResponse<void>;
      })
    );
  }

  /**
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `concertSpecConcertSpecIdPut$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  concertSpecConcertSpecIdPut(params: {
    concertSpecId: number;
    body?: ConcertSpecReqDto
  },
  context?: HttpContext

): Observable<void> {

    return this.concertSpecConcertSpecIdPut$Response(params,context).pipe(
      map((r: StrictHttpResponse<void>) => r.body as void)
    );
  }

  /**
   * Path part for operation concertSpecConcertSpecIdDelete
   */
  static readonly ConcertSpecConcertSpecIdDeletePath = '/ConcertSpec/{concertSpecId}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `concertSpecConcertSpecIdDelete()` instead.
   *
   * This method doesn't expect any request body.
   */
  concertSpecConcertSpecIdDelete$Response(params: {
    concertSpecId: number;
  },
  context?: HttpContext

): Observable<StrictHttpResponse<void>> {

    const rb = new RequestBuilder(this.rootUrl, ConcertSpecService.ConcertSpecConcertSpecIdDeletePath, 'delete');
    if (params) {
      rb.path('concertSpecId', params.concertSpecId, {});
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: '*/*',
      context: context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return (r as HttpResponse<any>).clone({ body: undefined }) as StrictHttpResponse<void>;
      })
    );
  }

  /**
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `concertSpecConcertSpecIdDelete$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  concertSpecConcertSpecIdDelete(params: {
    concertSpecId: number;
  },
  context?: HttpContext

): Observable<void> {

    return this.concertSpecConcertSpecIdDelete$Response(params,context).pipe(
      map((r: StrictHttpResponse<void>) => r.body as void)
    );
  }

}
