import { MatPaginatorIntl } from '@angular/material/paginator';

export function CustomPaginator() {
  const customPaginatorIntl = new MatPaginatorIntl();

  customPaginatorIntl.itemsPerPageLabel = 'Kayıt : ';
  customPaginatorIntl.previousPageLabel ="Önceki" ;
  customPaginatorIntl.nextPageLabel = "Sonraki";
  customPaginatorIntl.firstPageLabel ="İlk Sayfa";
  customPaginatorIntl.lastPageLabel = "Son Sayfa";
  customPaginatorIntl.getRangeLabel = getRangeLabel;

  return customPaginatorIntl;
}

const getRangeLabel = function (page, pageSize, length) {
    if (length === 0 || pageSize === 0) {
      return '0 kayıt.Toplam ' + length;
    }
    length = Math.max(length, 0);
    const startIndex = page * pageSize;
    // If the start index exceeds the list length, do not try and fix the end index to the end.
    const endIndex = startIndex < length ?
      Math.min(startIndex + pageSize, length) :
      startIndex + pageSize;
    return startIndex + 1 + ' - ' + endIndex + ' Arası Kayıt. Toplam : ' + length;
  };
