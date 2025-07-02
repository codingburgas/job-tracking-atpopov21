export interface BaseFilter<T> {
  page: number;
  pageSize: number;
  filters: T;
}
