import time
import cv2 as cv

def detect(img, cascade):
    """Detect faces or eyes using cascade classifier"""
    rects = cascade.detectMultiScale(
        img, 
        scaleFactor=1.3, 
        minNeighbors=4, 
        minSize=(30, 30),
        flags=cv.CASCADE_SCALE_IMAGE
    )
    if len(rects) == 0:
        return []
    # Convert to x1, y1, x2, y2 format
    rects[:, 2:] += rects[:, :2]
    return rects

def draw_rects(img, rects, color):
    """Draw rectangles on image"""
    for x1, y1, x2, y2 in rects:
        cv.rectangle(img, (x1, y1), (x2, y2), color, 2)

def draw_str(dst, target, s):
    """Draw text with shadow for visibility (replaces common.draw_str)"""
    x, y = target
    cv.putText(dst, s, (x + 1, y + 1), cv.FONT_HERSHEY_SIMPLEX, 0.5, (0, 0, 0), thickness=2, lineType=cv.LINE_AA)
    cv.putText(dst, s, (x, y), cv.FONT_HERSHEY_SIMPLEX, 0.5, (255, 255, 255), thickness=1, lineType=cv.LINE_AA)

def main():
    import sys
    import getopt

    args, video_src = getopt.getopt(sys.argv[1:], '', ['cascade=', 'nested-cascade='])
    try:
        video_src = video_src[0]
        # If it's a digit string, convert to int for webcam index
        if video_src.isdigit():
            video_src = int(video_src)
    except (IndexError, ValueError):
        video_src = 0
    
    args = dict(args)
    cascade_fn = args.get('--cascade', 'haarcascade_frontalface_alt.xml')
    nested_fn = args.get('--nested-cascade', 'haarcascade_eye.xml')

    # Load cascades using absolute data paths included in openCV package
    cascade_path = cv.data.haarcascades + cascade_fn
    nested_path = cv.data.haarcascades + nested_fn

    cascade = cv.CascadeClassifier(cascade_path)
    nested = cv.CascadeClassifier(nested_path)

    # Open camera or video natively
    cam = cv.VideoCapture(video_src)

    if not cam.isOpened():
        print(f"Error: Could not open video source {video_src}")
        return

    while True:
        ret, img = cam.read()
        if not ret:
            break
       
       
        # Convert to grayscale and equalize histogram
        img = cv.flip(img, 1)
        gray = cv.cvtColor(img, cv.COLOR_BGR2GRAY)
        gray = cv.equalizeHist(gray)

        # Measure detection time (replaces common.clock)
        t = time.time()
        
        # Detect faces
        rects = detect(gray, cascade)
        vis = img.copy()
        draw_rects(vis, rects, (0, 255, 0))  # Green rectangles for faces
        
        # Detect eyes within each face
        if not nested.empty():
            for x1, y1, x2, y2 in rects:
                roi = gray[y1:y2, x1:x2]
                vis_roi = vis[y1:y2, x1:x2]
                subrects = detect(roi.copy(), nested)
                draw_rects(vis_roi, subrects, (255, 0, 0))  # Blue for eyes
        
        dt = time.time() - t

        # Display detection time
        draw_str(vis, (20, 20), 'time: %.1f ms' % (dt * 1000))
        cv.imshow('Face Detection', vis)

        # Press ESC to exit
        if cv.waitKey(5) == 27:
            break

    print('Done')
    cam.release()
    cv.destroyAllWindows()

if __name__ == '__main__':
    main()