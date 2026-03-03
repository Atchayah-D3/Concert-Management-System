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

import { ConcertReqDto } from '../models/concert-req-dto';
import { ConcertResDto } from '../models/concert-res-dto';

@Injectable({
  providedIn: 'root',
})
export class ConcertService extends BaseService {
  constructor(
    config: ApiConfiguration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * Path part for operation concertGet
   */
  static readonly ConcertGetPath = '/Concert';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `concertGet()` instead.
   *
   * This method doesn't expect any request body.
   */
  concertGet$Response(params?: {
  },
  context?: HttpContext

): Observable<StrictHttpResponse<Array<ConcertResDto>>> {

    const rb = new RequestBuilder(this.rootUrl, ConcertService.ConcertGetPath, 'get');
    if (params) {
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'application/json',
      context: context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Array<ConcertResDto>>;
      })
    );
  }

  /**
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `concertGet$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  concertGet(params?: {
  },
  context?: HttpContext

): Observable<Array<ConcertResDto>> {

    return this.concertGet$Response(params,context).pipe(
      map((r: StrictHttpResponse<Array<ConcertResDto>>) => r.body as Array<ConcertResDto>)
    );
  }

  /**
   * Path part for operation concertPost
   */
  static readonly ConcertPostPath = '/Concert';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `concertPost()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  concertPost$Response(params?: {
    body?: ConcertReqDto
  },
  context?: HttpContext

): Observable<StrictHttpResponse<ConcertResDto>> {

    const rb = new RequestBuilder(this.rootUrl, ConcertService.ConcertPostPath, 'post');
    if (params) {
      rb.body(params.body, 'application/*+json');
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'application/json',
      context: context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<ConcertResDto>;
      })
    );
  }

  /**
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `concertPost$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  concertPost(params?: {
    body?: ConcertReqDto
  },
  context?: HttpContext

): Observable<ConcertResDto> {

    return this.concertPost$Response(params,context).pipe(
      map((r: StrictHttpResponse<ConcertResDto>) => r.body as ConcertResDto)
    );
  }

  /**
   * Path part for operation concertIdGet
   */
  static readonly ConcertIdGetPath = '/Concert/{id}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `concertIdGet()` instead.
   *
   * This method doesn't expect any request body.
   */
  concertIdGet$Response(params: {
    id: number;
  },
  context?: HttpContext

): Observable<StrictHttpResponse<ConcertResDto>> {

    const rb = new RequestBuilder(this.rootUrl, ConcertService.ConcertIdGetPath, 'get');
    if (params) {
      rb.path('id', params.id, {});
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'application/json',
      context: context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<ConcertResDto>;
      })
    );
  }

  /**
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `concertIdGet$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  concertIdGet(params: {
    id: number;
  },
  context?: HttpContext

): Observable<ConcertResDto> {

    return this.concertIdGet$Response(params,context).pipe(
      map((r: StrictHttpResponse<ConcertResDto>) => r.body as ConcertResDto)
    );
  }

  /**
   * Path part for operation concertIdPut
   */
  static readonly ConcertIdPutPath = '/Concert/{id}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `concertIdPut()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  concertIdPut$Response(params: {
    id: number;
    body?: ConcertReqDto
  },
  context?: HttpContext

): Observable<StrictHttpResponse<ConcertResDto>> {

    const rb = new RequestBuilder(this.rootUrl, ConcertService.ConcertIdPutPath, 'put');
    if (params) {
      rb.path('id', params.id, {});
      rb.body(params.body, 'application/*+json');
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'application/json',
      context: context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<ConcertResDto>;
      })
    );
  }

  /**
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `concertIdPut$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  concertIdPut(params: {
    id: number;
    body?: ConcertReqDto
  },
  context?: HttpContext

): Observable<ConcertResDto> {

    return this.concertIdPut$Response(params,context).pipe(
      map((r: StrictHttpResponse<ConcertResDto>) => r.body as ConcertResDto)
    );
  }

  /**
   * Path part for operation concertIdDelete
   */
  static readonly ConcertIdDeletePath = '/Concert/{id}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `concertIdDelete()` instead.
   *
   * This method doesn't expect any request body.
   */
  concertIdDelete$Response(params: {
    id: number;
  },
  context?: HttpContext

): Observable<StrictHttpResponse<void>> {

    const rb = new RequestBuilder(this.rootUrl, ConcertService.ConcertIdDeletePath, 'delete');
    if (params) {
      rb.path('id', params.id, {});
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
   * To access the full response (for headers, for example), `concertIdDelete$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  concertIdDelete(params: {
    id: number;
  },
  context?: HttpContext

): Observable<void> {

    return this.concertIdDelete$Response(params,context).pipe(
      map((r: StrictHttpResponse<void>) => r.body as void)
    );
  }

}
