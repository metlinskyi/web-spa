// This file is auto-generated by @hey-api/openapi-ts

export type TranslationJobModel = {
    id?: string | null;
    customerName?: string | null;
    status?: string | null;
    originalContent?: string | null;
    translatedContent?: string | null;
    price?: number;
};

export type JobStatus = 0 | 1 | 2 | 3;

export type TranslatorModel = {
    id?: string | null;
    name?: string | null;
    hourlyRate?: string | null;
    status?: string | null;
    creditCardNumber?: string | null;
};

export type TranslatorStatus = 0 | 1 | 2 | 3;

export type GetApiV1JobsGetJobsResponse = Array<TranslationJobModel>;

export type PostApiV1JobsCreateJobData = {
    requestBody?: TranslationJobModel;
};

export type PostApiV1JobsCreateJobResponse = boolean;

export type PostApiV1JobsCreateJobWithFileData = {
    customer?: string | null;
    formData?: {
        file?: (Blob | File) | null;
    };
};

export type PostApiV1JobsCreateJobWithFileResponse = boolean;

export type PostApiV1JobsUpdateJobStatusData = {
    jobId?: string;
    newStatus?: JobStatus;
    translatorId?: string;
};

export type PostApiV1JobsUpdateJobStatusResponse = string;

export type GetApiV1TranslatorsManagementGetTranslatorsResponse = Array<TranslatorModel>;

export type GetApiV1TranslatorsManagementGetTranslatorsByNameData = {
    name?: string | null;
};

export type GetApiV1TranslatorsManagementGetTranslatorsByNameResponse = Array<TranslatorModel>;

export type PostApiV1TranslatorsManagementAddTranslatorData = {
    requestBody?: TranslatorModel;
};

export type PostApiV1TranslatorsManagementAddTranslatorResponse = boolean;

export type PostApiV1TranslatorsManagementUpdateTranslatorStatusData = {
    newStatus?: TranslatorStatus;
    translatorId?: string;
};

export type PostApiV1TranslatorsManagementUpdateTranslatorStatusResponse = string;

export type $OpenApiTs = {
    '/api/v1/jobs/GetJobs': {
        get: {
            res: {
                /**
                 * Success
                 */
                200: Array<TranslationJobModel>;
            };
        };
    };
    '/api/v1/jobs/CreateJob': {
        post: {
            req: PostApiV1JobsCreateJobData;
            res: {
                /**
                 * Success
                 */
                200: boolean;
            };
        };
    };
    '/api/v1/jobs/CreateJobWithFile': {
        post: {
            req: PostApiV1JobsCreateJobWithFileData;
            res: {
                /**
                 * Success
                 */
                200: boolean;
            };
        };
    };
    '/api/v1/jobs/UpdateJobStatus': {
        post: {
            req: PostApiV1JobsUpdateJobStatusData;
            res: {
                /**
                 * Success
                 */
                200: string;
            };
        };
    };
    '/api/v1/TranslatorsManagement/GetTranslators': {
        get: {
            res: {
                /**
                 * Success
                 */
                200: Array<TranslatorModel>;
            };
        };
    };
    '/api/v1/TranslatorsManagement/GetTranslatorsByName': {
        get: {
            req: GetApiV1TranslatorsManagementGetTranslatorsByNameData;
            res: {
                /**
                 * Success
                 */
                200: Array<TranslatorModel>;
            };
        };
    };
    '/api/v1/TranslatorsManagement/AddTranslator': {
        post: {
            req: PostApiV1TranslatorsManagementAddTranslatorData;
            res: {
                /**
                 * Success
                 */
                200: boolean;
            };
        };
    };
    '/api/v1/TranslatorsManagement/UpdateTranslatorStatus': {
        post: {
            req: PostApiV1TranslatorsManagementUpdateTranslatorStatusData;
            res: {
                /**
                 * Success
                 */
                200: string;
            };
        };
    };
};