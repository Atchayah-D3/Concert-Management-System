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

import { HallDto } from '../models/hall-dto';

@Injectable({
  providedIn: 'root',
})
export class HallService extends BaseService {
  constructor(
    config: ApiConfiguration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * Path part for operation hallGet
   */
  static readonly HallGetPath = '/Hall';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `hallGet$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  hallGet$Plain$Response(params?: {
  },
  context?: HttpContext

): Observable<StrictHttpResponse<Array<HallDto>>> {

    const rb = new RequestBuilder(this.rootUrl, HallService.HallGetPath, 'get');
    if (params) {
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain',
      context: context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Array<HallDto>>;
      })
    );
  }

  /**
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `hallGet$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  hallGet$Plain(params?: {
  },
  context?: HttpContext

): Observable<Array<HallDto>> {

    return this.hallGet$Plain$Response(params,context).pipe(
      map((r: StrictHttpResponse<Array<HallDto>>) => r.body as Array<HallDto>)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `hallGet$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  hallGet$Json$Response(params?: {
  },
  context?: HttpContext

): Observable<StrictHttpResponse<Array<HallDto>>> {

    const rb = new RequestBuilder(this.rootUrl, HallService.HallGetPath, 'get');
    if (params) {
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json',
      context: context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Array<HallDto>>;
      })
    );
  }

  /**
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `hallGet$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  hallGet$Json(params?: {
  },
  context?: HttpContext

): Observable<Array<HallDto>> {

    return this.hallGet$Json$Response(params,context).pipe(
      map((r: StrictHttpResponse<Array<HallDto>>) => r.body as Array<HallDto>)
    );
  }

  /**
   * Path part for operation hallPost
   */
  static readonly HallPostPath = '/Hall';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `hallPost$Plain()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  hallPost$Plain$Response(params?: {
    body?: HallDto
  },
  context?: HttpContext

): Observable<StrictHttpResponse<HallDto>> {

    const rb = new RequestBuilder(this.rootUrl, HallService.HallPostPath, 'post');
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
        return r as StrictHttpResponse<HallDto>;
      })
    );
  }

  /**
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `hallPost$Plain$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  hallPost$Plain(params?: {
    body?: HallDto
  },
  context?: HttpContext

): Observable<HallDto> {

    return this.hallPost$Plain$Response(params,context).pipe(
      map((r: StrictHttpResponse<HallDto>) => r.body as HallDto)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `hallPost$Json()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  hallPost$Json$Response(params?: {
    body?: HallDto
  },
  context?: HttpContext

): Observable<StrictHttpResponse<HallDto>> {

    const rb = new RequestBuilder(this.rootUrl, HallService.HallPostPath, 'post');
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
        return r as StrictHttpResponse<HallDto>;
      })
    );
  }

  /**
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `hallPost$Json$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  hallPost$Json(params?: {
    body?: HallDto
  },
  context?: HttpContext

): Observable<HallDto> {

    return this.hallPost$Json$Response(params,context).pipe(
      map((r: StrictHttpResponse<HallDto>) => r.body as HallDto)
    );
  }

  /**
   * Path part for operation hallIdGet
   */
  static readonly HallIdGetPath = '/Hall/{id}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `hallIdGet$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  hallIdGet$Plain$Response(params: {
    id: number;
  },
  context?: HttpContext

): Observable<StrictHttpResponse<HallDto>> {

    const rb = new RequestBuilder(this.rootUrl, HallService.HallIdGetPath, 'get');
    if (params) {
      rb.path('id', params.id, {});
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain',
      context: context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<HallDto>;
      })
    );
  }

  /**
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `hallIdGet$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  hallIdGet$Plain(params: {
    id: number;
  },
  context?: HttpContext

): Observable<HallDto> {

    return this.hallIdGet$Plain$Response(params,context).pipe(
      map((r: StrictHttpResponse<HallDto>) => r.body as HallDto)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `hallIdGet$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  hallIdGet$Json$Response(params: {
    id: number;
  },
  context?: HttpContext

): Observable<StrictHttpResponse<HallDto>> {

    const rb = new RequestBuilder(this.rootUrl, HallService.HallIdGetPath, 'get');
    if (params) {
      rb.path('id', params.id, {});
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json',
      context: context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<HallDto>;
      })
    );
  }

  /**
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `hallIdGet$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  hallIdGet$Json(params: {
    id: number;
  },
  context?: HttpContext

): Observable<HallDto> {

    return this.hallIdGet$Json$Response(params,context).pipe(
      map((r: StrictHttpResponse<HallDto>) => r.body as HallDto)
    );
  }

  /**
   * Path part for operation hallIdPut
   */
  static readonly HallIdPutPath = '/Hall/{id}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `hallIdPut$Plain()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  hallIdPut$Plain$Response(params: {
    id: number;
    body?: HallDto
  },
  context?: HttpContext

): Observable<StrictHttpResponse<HallDto>> {

    const rb = new RequestBuilder(this.rootUrl, HallService.HallIdPutPath, 'put');
    if (params) {
      rb.path('id', params.id, {});
      rb.body(params.body, 'application/*+json');
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain',
      context: context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<HallDto>;
      })
    );
  }

  /**
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `hallIdPut$Plain$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  hallIdPut$Plain(params: {
    id: number;
    body?: HallDto
  },
  context?: HttpContext

): Observable<HallDto> {

    return this.hallIdPut$Plain$Response(params,context).pipe(
      map((r: StrictHttpResponse<HallDto>) => r.body as HallDto)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `hallIdPut$Json()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  hallIdPut$Json$Response(params: {
    id: number;
    body?: HallDto
  },
  context?: HttpContext

): Observable<StrictHttpResponse<HallDto>> {

    const rb = new RequestBuilder(this.rootUrl, HallService.HallIdPutPath, 'put');
    if (params) {
      rb.path('id', params.id, {});
      rb.body(params.body, 'application/*+json');
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json',
      context: context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<HallDto>;
      })
    );
  }

  /**
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `hallIdPut$Json$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  hallIdPut$Json(params: {
    id: number;
    body?: HallDto
  },
  context?: HttpContext

): Observable<HallDto> {

    return this.hallIdPut$Json$Response(params,context).pipe(
      map((r: StrictHttpResponse<HallDto>) => r.body as HallDto)
    );
  }

}
