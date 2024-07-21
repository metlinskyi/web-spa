// This file is auto-generated by @hey-api/openapi-ts

import type { CancelablePromise } from './core/CancelablePromise';
import { OpenAPI } from './core/OpenAPI';
import { request as __request } from './core/request';
import type { GetApiV1JobsGetJobsResponse, PostApiV1JobsCreateJobData, PostApiV1JobsCreateJobResponse, PostApiV1JobsCreateJobWithFileData, PostApiV1JobsCreateJobWithFileResponse, PostApiV1JobsUpdateJobStatusData, PostApiV1JobsUpdateJobStatusResponse, GetApiV1TranslatorsManagementGetTranslatorsResponse, GetApiV1TranslatorsManagementGetTranslatorsByNameData, GetApiV1TranslatorsManagementGetTranslatorsByNameResponse, PostApiV1TranslatorsManagementAddTranslatorData, PostApiV1TranslatorsManagementAddTranslatorResponse, PostApiV1TranslatorsManagementUpdateTranslatorStatusData, PostApiV1TranslatorsManagementUpdateTranslatorStatusResponse } from './types.gen';

/**
 * @returns TranslationJobModel Success
 * @throws ApiError
 */
export const getApiV1JobsGetJobs = (): CancelablePromise<GetApiV1JobsGetJobsResponse> => { return __request(OpenAPI, {
    method: 'GET',
    url: '/api/v1/jobs/GetJobs'
}); };

/**
 * @param data The data for the request.
 * @param data.requestBody
 * @returns boolean Success
 * @throws ApiError
 */
export const postApiV1JobsCreateJob = (data: PostApiV1JobsCreateJobData = {}): CancelablePromise<PostApiV1JobsCreateJobResponse> => { return __request(OpenAPI, {
    method: 'POST',
    url: '/api/v1/jobs/CreateJob',
    body: data.requestBody,
    mediaType: 'application/json'
}); };

/**
 * @param data The data for the request.
 * @param data.customer
 * @param data.formData
 * @returns boolean Success
 * @throws ApiError
 */
export const postApiV1JobsCreateJobWithFile = (data: PostApiV1JobsCreateJobWithFileData = {}): CancelablePromise<PostApiV1JobsCreateJobWithFileResponse> => { return __request(OpenAPI, {
    method: 'POST',
    url: '/api/v1/jobs/CreateJobWithFile',
    query: {
        customer: data.customer
    },
    formData: data.formData,
    mediaType: 'multipart/form-data'
}); };

/**
 * @param data The data for the request.
 * @param data.jobId
 * @param data.translatorId
 * @param data.newStatus
 * @returns string Success
 * @throws ApiError
 */
export const postApiV1JobsUpdateJobStatus = (data: PostApiV1JobsUpdateJobStatusData = {}): CancelablePromise<PostApiV1JobsUpdateJobStatusResponse> => { return __request(OpenAPI, {
    method: 'POST',
    url: '/api/v1/jobs/UpdateJobStatus',
    query: {
        jobId: data.jobId,
        translatorId: data.translatorId,
        newStatus: data.newStatus
    }
}); };

/**
 * @returns TranslatorModel Success
 * @throws ApiError
 */
export const getApiV1TranslatorsManagementGetTranslators = (): CancelablePromise<GetApiV1TranslatorsManagementGetTranslatorsResponse> => { return __request(OpenAPI, {
    method: 'GET',
    url: '/api/v1/TranslatorsManagement/GetTranslators'
}); };

/**
 * @param data The data for the request.
 * @param data.name
 * @returns TranslatorModel Success
 * @throws ApiError
 */
export const getApiV1TranslatorsManagementGetTranslatorsByName = (data: GetApiV1TranslatorsManagementGetTranslatorsByNameData = {}): CancelablePromise<GetApiV1TranslatorsManagementGetTranslatorsByNameResponse> => { return __request(OpenAPI, {
    method: 'GET',
    url: '/api/v1/TranslatorsManagement/GetTranslatorsByName',
    query: {
        name: data.name
    }
}); };

/**
 * @param data The data for the request.
 * @param data.requestBody
 * @returns boolean Success
 * @throws ApiError
 */
export const postApiV1TranslatorsManagementAddTranslator = (data: PostApiV1TranslatorsManagementAddTranslatorData = {}): CancelablePromise<PostApiV1TranslatorsManagementAddTranslatorResponse> => { return __request(OpenAPI, {
    method: 'POST',
    url: '/api/v1/TranslatorsManagement/AddTranslator',
    body: data.requestBody,
    mediaType: 'application/json'
}); };

/**
 * @param data The data for the request.
 * @param data.translatorId
 * @param data.newStatus
 * @returns string Success
 * @throws ApiError
 */
export const postApiV1TranslatorsManagementUpdateTranslatorStatus = (data: PostApiV1TranslatorsManagementUpdateTranslatorStatusData = {}): CancelablePromise<PostApiV1TranslatorsManagementUpdateTranslatorStatusResponse> => { return __request(OpenAPI, {
    method: 'POST',
    url: '/api/v1/TranslatorsManagement/UpdateTranslatorStatus',
    query: {
        translatorId: data.translatorId,
        newStatus: data.newStatus
    }
}); };