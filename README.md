# Windows tray icon UUID generator

This is a simple UUID generator that is accessible via the
tray icon area on Windows. It supports generating UUIDs in
registry format

```
{8e3d5ffb-80e3-48c8-b5fe-546232ae471f}
```

as a C/C++ header inclusion guard of the form

```
#ifndef __is_included__61475e38_1b28_4956_946e_a14f08bfa69f
#define __is_included__61475e38_1b28_4956_946e_a14f08bfa69f


#endif /* __is_included__61475e38_1b28_4956_946e_a14f08bfa69f */
```

or as the same inclusion guard with additional `extern "C"`
statements:

```
#ifndef __is_included__bbb9dc26_e153_4662_985f_544de5cb6283
#define __is_included__bbb9dc26_e153_4662_985f_544de5cb6283

#ifdef __cplusplus
	extern "C" {
#endif



#ifdef __cplusplus
	} /* extern "C" */
#endif


#endif /* __is_included__bbb9dc26_e153_4662_985f_544de5cb6283 */
```